using model;
using System;
using System.Collections.Generic;
using System.Data;


namespace persistance {
    public class ParticipantEventDbRepository : IParticipantEventRepository {

        public void delete(EventPartDTO e) {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "DELETE FROM ParticipantEvent WHERE CodP=@c AND Distance=@d AND Style=@s";
                IDbDataParameter paramCod = comm.CreateParameter();
                paramCod.ParameterName = "@c";
                paramCod.Value = e.CodPart;
                comm.Parameters.Add(paramCod);

                IDbDataParameter paramDist = comm.CreateParameter();
                paramDist.ParameterName = "@d";
                paramDist.Value = e.Distance;
                comm.Parameters.Add(paramDist);

                IDbDataParameter paramStyle = comm.CreateParameter();
                paramStyle.ParameterName = "@s";
                paramStyle.Value = e.Style;
                comm.Parameters.Add(paramStyle);
                var dataR = comm.ExecuteNonQuery();
                //if (dataR == 0)
                //    throw new RepositoryException("No task deleted!");
            }
        }

        public IEnumerable<EventPartDTO> findAll() {
            throw new NotImplementedException();
        }

        public EventPartDTO findOne(EventPartDTO e) {
            throw new NotImplementedException();
        }

        public void save(EventPartDTO e) {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "INSERT INTO ParticipantEvent (CodP, Distance, Style) VALUES (@codP,@d,@s)";
                var paramCod = comm.CreateParameter();
                paramCod.ParameterName = "@codP";
                paramCod.Value = e.CodPart;
                comm.Parameters.Add(paramCod);

                var paramDist = comm.CreateParameter();
                paramDist.ParameterName = "@d";
                paramDist.Value = e.Distance;
                comm.Parameters.Add(paramDist);

                var paramStyle = comm.CreateParameter();
                paramStyle.ParameterName = "@s";
                paramStyle.Value = e.Style;
                comm.Parameters.Add(paramStyle);

                var result = comm.ExecuteNonQuery();
            }
        }

        public IEnumerable<Event> findAllEventsForPart(int codP) {
            IDbConnection con = DBUtils.getConnection();
            IList<Event> events = new List<Event>();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "SELECT Distance, Style FROm ParticipantEvent WHERE CodP=@c";
                IDbDataParameter paramCod = comm.CreateParameter();
                paramCod.ParameterName = "@c";
                paramCod.Value = codP;
                comm.Parameters.Add(paramCod);
                using (var dataR = comm.ExecuteReader()) {
                    while (dataR.Read()) {
                        int distance = dataR.GetInt32(0);
                        String style = dataR.GetString(1);
                        Event ev = new Event(distance,style);
                        events.Add(ev);
                    }
                }
            }
            return events;
            }

        public IEnumerable<EventPartDTO> findEventsNosParticipants() {
            IDbConnection con = DBUtils.getConnection();
            IList<EventPartDTO> events = new List<EventPartDTO>();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "SELECT e.Distance, e.Style,ifnull(t.NoParticipants,0) as NoParticipants FROM(SELECT Distance, Style, Count(*) As NoParticipants FROM participantevent group by Distance, Style) AS t right join swimmingevent e on e.Distance=t.Distance and e.Style=t.Style;";
                using (var dataR = comm.ExecuteReader()) {
                    while (dataR.Read()) {
                        int nrP = dataR.GetInt32(2);
                        int distance = dataR.GetInt32(0);
                        String style = dataR.GetString(1);
                        events.Add(new EventPartDTO(distance, style, nrP));
                    }
                }
            }
            return events;
        }

        public IEnumerable<Participant> findPartForEvent(Event e) {
            IDbConnection con = DBUtils.getConnection();
            IList<Participant> parts = new List<Participant>();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "SELECT p.CodP, p.Nume, p.Age FROm participantevent pe inner join participant p on p.CodP=pe.CodP  WHERE Distance=@d  AND Style=@s";
                IDbDataParameter paramDist = comm.CreateParameter();
                paramDist.ParameterName = "@d";
                paramDist.Value = e.Id.Item1;
                comm.Parameters.Add(paramDist);
                IDbDataParameter paramStyle = comm.CreateParameter();
                paramStyle.ParameterName = "@s";
                paramStyle.Value = e.Id.Item2;
                comm.Parameters.Add(paramStyle);
                using (var dataR = comm.ExecuteReader()) {
                    while (dataR.Read()) {
                        int cod = dataR.GetInt32(0);
                        string name = dataR.GetString(1);
                        int age = dataR.GetInt32(2);
                        parts.Add(new Participant(cod,name, age));
                    }
                }
            }
            return parts;
        }

        //public IEnumerable<int> findParticipantForEvent(Event e) {
        //    IDbConnection con = DBUtils.getConnection();
        //    IList<int> parts = new List<int>();
        //    using (var comm = con.CreateCommand()) {
        //        comm.CommandText = "SELECT CodP FROm participantevent  WHERE Distance=@d  AND Style=@s";
        //        IDbDataParameter paramDist = comm.CreateParameter();
        //        paramDist.ParameterName = "@d";
        //        paramDist.Value = e.Id.Item1;
        //        comm.Parameters.Add(paramDist);
        //        IDbDataParameter paramStyle = comm.CreateParameter();
        //        paramStyle.ParameterName = "@s";
        //        paramStyle.Value = e.Id.Item2;
        //        comm.Parameters.Add(paramStyle);
        //        using (var dataR = comm.ExecuteReader()) {
        //            while (dataR.Read()) {
        //                int nrP = dataR.GetInt32(0);
        //                parts.Add(nrP);
        //            }
        //        }
        //    }
        //    return parts;
        //}
    }
}
