using System;
using LPCS.Server.Data.Mongo.Entities;
using LPCS.Server.Data.Mongo.Repositories;
using MongoDB.Driver;

namespace LPCS.Server.Data.Mongo 
{
    public class LpcsMongoContext 
    {
        public ProfileRepository Profiles { get; }
        public MessageRepository Messages { get; }
        public LogRepository Logs { get; }

        public LpcsMongoContext(string connectionString)
        {
            Profiles = new ProfileRepository(connectionString, "profiles");

            Profiles.Collection.Indexes.CreateOne
            (
                  Builders<Profile>.IndexKeys
                    .Ascending(_ => _.Supervisor.CredentialInitials)
                    .Ascending(_ => _.Supervisor.LicenseState)
                    .Ascending(_ => _.Supervisor.ClientDescription)
                    .Ascending(_ => _.Supervisor.SpecialtyDescription)
                    .Ascending(_ => _.Supervisor.UniqueDescription),
                new CreateIndexOptions { Sparse = true, Name = Guid.NewGuid().ToString() }
            );

            Logs = new LogRepository(connectionString, "logs");
        }

    }
}