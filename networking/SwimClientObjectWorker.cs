using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using services;
using networking;
using model;

namespace networking {
    public class SwimClientWorker : ISwimObserver {
        private ISwimServer server;
        private TcpClient connection;
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;

        public SwimClientWorker(ISwimServer server, TcpClient connection) {
            this.server = server;
            this.connection = connection;
            try {

                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run() {
            while (connected) {
                try {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response != null) {
                        sendResponse((Response)response);
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.StackTrace);
                }

                try {
                    Thread.Sleep(1000);
                } catch (Exception e) {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try {
                stream.Close();
                connection.Close();
            } catch (Exception e) {
                Console.WriteLine("Error " + e);
            }
        }

        private Response handleRequest(Request request) {
            Response response = null;
            if (request is LoginRequest) {
                Console.WriteLine("Login request ...");
                LoginRequest logReq = (LoginRequest)request;
                Organizer org = logReq.Organizer;

                try {
                    lock (server) {
                        server.login(org, this);
                    }
                    return new OkResponse();
                } catch (SwimException e) {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is LogoutRequest) {
                Console.WriteLine("Logout request");
                LogoutRequest logReq = (LogoutRequest)request;
                Organizer org = logReq.Organizer;
                try {
                    lock (server) {

                        server.logout(org, this);
                    }
                    connected = false;
                    return new OkResponse();

                } catch (SwimException e) {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetEventsNosPartRequest) {
                Console.WriteLine("GetEventsNosPartRequest request ...");
                try {
                    lock (server) {
                        return new GetEventsNosPartResponse(server.findEventsNosParticipants());
                    }
                } catch (SwimException e) {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is GetAllPart4EventRequest) {
                Console.WriteLine("Searching participants for event...");
                GetAllPart4EventRequest partReq = (GetAllPart4EventRequest)request;
                Event ev = partReq.Event;
                try {
                    lock (server) {
                        return new GetAllPart4EventResponse( server.findPartForEvent(ev));
                    }
                } catch (SwimException e) {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is GetAllPartRequest) {
                Console.WriteLine("Searching all participants...");
                try {
                    lock (server) {
                        return new GetAllPartResponse(server.findAllParticipants());
                    }
                } catch (SwimException e) {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is AddPart2EventRequest) {
                Console.WriteLine("Adding participant to event...");
                AddPart2EventRequest partReq = (AddPart2EventRequest)request;
                EventPartDTO ev = partReq.EventPartDTOent;
                try {
                    lock (server) {
                        server.addPart2Event(ev);
                    }
                    return new OkResponse();
                } catch (SwimException e) {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is AddParticipantRequest) {
                Console.WriteLine("Adding participant...");
                AddParticipantRequest partReq = (AddParticipantRequest)request;
                Participant part = partReq.Participant;
                try {
                    lock (server) {
                        server.addParticipant(part);
                    }
                    return new OkResponse();
                } catch (SwimException e) {
                    return new ErrorResponse(e.Message);
                }
            }

            return response;
        }

        private void sendResponse(Response response) {
            Console.WriteLine("sending response " + response);
            formatter.Serialize(stream, response);
            stream.Flush();

        }

        public virtual void UpdateObserver() {
            Console.WriteLine("Updating all clients...");
            Console.WriteLine("1111111111111111111...");
            try {
                sendResponse(new UpdateNowResponse());
                Console.WriteLine("222222222222222222...");
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void AddParticipantObserver(Participant part) {
            Console.WriteLine("Participant received  " + part.Name);
            try {
                sendResponse(new AddParticipantObsResponse(part));
            } catch (Exception e) {
                throw new SwimException("Sending error: " + e);
            }
        }
    }
}