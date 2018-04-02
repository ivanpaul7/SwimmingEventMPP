using System;
using System.Collections.Generic;
using System.Data;
using model;

namespace persistance {
    public class ParticipantDbRepository : IParticipantRepository {
        public ParticipantDbRepository() {}


        public void delete(int id) {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "DELETE FROM Participant WHERE CodP=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                //if (dataR == 0)
                //    throw new RepositoryException("No task deleted!");
            }
        }

        public IEnumerable<Participant> findAll() {
            IDbConnection con = DBUtils.getConnection();
            IList<Participant> parts = new List<Participant>();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "select * from Participant";
                using (var dataR = comm.ExecuteReader()) {
                    while (dataR.Read()) {
                        int codP = dataR.GetInt32(0);
                        String name = dataR.GetString(1);
                        int age = dataR.GetInt32(2);
                        Participant part = new Participant(codP, name, age);
                        parts.Add(part);
                    }
                }
            }
            return parts;
       }

        public Participant findOne(int id) {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "select * from Participant where CodP=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader()) {
                    if (dataR.Read()) {
                        int codP = dataR.GetInt32(0);
                        String name = dataR.GetString(1);
                        int age = dataR.GetInt32(2);
                        Participant part = new Participant(codP, name, age);
                        return part;
                    }
                }
            }
            return null;
        }

        public void save(Participant e) {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "INSERT INTO participant (CodP, Nume, Age) VALUES (@codP, @n, @a)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@codP";
                paramId.Value = e.Id;
                comm.Parameters.Add(paramId);

                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@n";
                paramName.Value = e.Name;
                comm.Parameters.Add(paramName);

                var paramAge = comm.CreateParameter();
                paramAge.ParameterName = "@a";
                paramAge.Value = e.Age;
                comm.Parameters.Add(paramAge);

                var result = comm.ExecuteNonQuery();
                //if (result == 0)
                //    throw new RepositoryException("No participant added !");
            }
       }
    }
}
