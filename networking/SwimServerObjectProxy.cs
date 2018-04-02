using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using model;
using services;

namespace networking {
    public class SwimServerProxy : ISwimServer {
        private string host;
        private int port;

        private ISwimObserver client;

        private NetworkStream stream;

        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        public SwimServerProxy(string host, int port) {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }


        public virtual void login(Organizer org, ISwimObserver client) {
            initializeConnection();
            sendRequest(new LoginRequest(org));
            Response response = readResponse();
            if (response is OkResponse) {
                this.client = client;
                return;
            }
            if (response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new SwimException(err.Message);
            }
        }

        public virtual void logout(Organizer org, ISwimObserver obs) {
            {
                sendRequest(new LogoutRequest(org));
                Response response = readResponse();
                closeConnection();
                if (response is ErrorResponse) {
                    ErrorResponse err = (ErrorResponse)response;
                    throw new SwimException(err.Message);
                }
            }
        }

        public virtual EventPartDTO[] findEventsNosParticipants() {
            initializeConnection();
            sendRequest(new GetEventsNosPartRequest());
            Response response = readResponse();
            if (response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                throw new SwimException(err.Message);
            }
            GetEventsNosPartResponse resp = (GetEventsNosPartResponse)response;
            return resp.EventsNosPart;
            
        }

        public virtual Participant[] findAllParticipants() {
            initializeConnection();
            sendRequest(new GetAllPartRequest());
            Response response = readResponse();
            if (response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                throw new SwimException(err.Message);
            }
            GetAllPartResponse resp = (GetAllPartResponse)response;
            return resp.Participants;
        }

        public virtual Participant[] findPartForEvent(Event e) {
            initializeConnection();
            sendRequest(new GetAllPart4EventRequest(e));
            Response response = readResponse();
            if (response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                throw new SwimException(err.Message);
            }
            GetAllPart4EventResponse resp = (GetAllPart4EventResponse)response;
            return resp.Participants;
        }

        public virtual void addParticipant(Participant participant) {
            initializeConnection();
            sendRequest(new AddParticipantRequest(participant));
            Response response = readResponse();
            if (response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                throw new SwimException(err.Message);
            }
        }

        public virtual void addPart2Event(EventPartDTO e) {
            initializeConnection();
            sendRequest(new AddPart2EventRequest(e));
            Response response = readResponse();
            if (response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                throw new SwimException(err.Message);
            }
        }

        private void closeConnection() {
            finished = true;
            try {
                stream.Close();
                //output.close();
                connection.Close();
                _waitHandle.Close();
                client = null;
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }

        }
        private void sendRequest(Request request) {
            try {
                formatter.Serialize(stream, request);
                stream.Flush();
            } catch (Exception e) {
                throw new SwimException("Error sending object " + e);
            }

        }

        private Response readResponse() {
            Response response = null;
            try {
                _waitHandle.WaitOne();
                lock (responses) {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();

                }


            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        private void initializeConnection() {
            try {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader() {
            Thread tw = new Thread(run);
            tw.Start();
        }
        public virtual void run() {
            while (!finished) {
                try {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received" + response);
                    if (response is UpdateResponse) {
                        handleUpdate((UpdateResponse)response);
                    } else {
                        lock (responses) {
                            responses.Enqueue((Response)response);
                        }
                        _waitHandle.Set();
                    }
                } catch (Exception e) {
                    Console.WriteLine("Reading error " + e);
                }

            }
        }
        private void handleUpdate(UpdateResponse update) {
            if (update is UpdateNowResponse) {
                try {
                    client.UpdateObserver();
                } catch (SwimException e) {
                    Console.WriteLine(e.StackTrace);
                }
            }
            if (update is AddParticipantObsResponse) {
                AddParticipantObsResponse addRes = (AddParticipantObsResponse)update;
                try {
                    client.AddParticipantObserver(addRes.Participant);
                } catch (SwimException e) {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
