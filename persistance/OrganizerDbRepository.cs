using System;
using System.Collections.Generic;
using model;
using System.Data;

namespace persistance {
    public class OrganizerDbRepository : IOrganizerRepository {
        public bool checkUserPass(Organizer org) {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "SELECT COUNT(*) FROM Organizer WHERE Username=@id AND Password=@pass";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = org.Id;
                comm.Parameters.Add(paramId);
                IDbDataParameter paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@pass";
                paramPass.Value = org.Password;
                comm.Parameters.Add(paramPass);

                using (var dataR = comm.ExecuteReader()) {
                    if (dataR.Read()) {
                        int found = dataR.GetInt32(0);
                        if (found == 1)
                            return true;
                        return false;
                    }
                }
            }
            return false;
        }

        public void delete(string id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Organizer> findAll() {
            throw new NotImplementedException();
        }

        public Organizer findOne(string id) {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "SELECT * FROM Organizer WHERE Username=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader()) {
                    if (dataR.Read()) {
                        String username = dataR.GetString(0);
                        String password = dataR.GetString(1);
                        String name = dataR.GetString(2);
                        Organizer org = new Organizer(username,password, name);
                        return org;
                    }
                }
            }
            return null;
        }

        public void save(Organizer e) {
            throw new NotImplementedException();
        }
    }
}
