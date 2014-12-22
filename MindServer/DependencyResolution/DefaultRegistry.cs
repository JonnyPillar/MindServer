// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using MindServer.EF;
using MindServer.Services;
using MindServer.Services.Interfaces;
using MindServer.Services.Repository;
using MindServer.Services.Repository.DataLayer;
using MindServer.Services.Repository.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace MindServer.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            ObjectFactory.Initialize(cfg => cfg.Scan(scan =>
            {
                For<DbContext>().Use<MindServerDbContext>();
                For<IUnitOfWork>().Use<EFUnitOfWork>();
                For<IUserRepository>().Use<UserRepository>();
                For<IAudioFileRepository>().Use<AudioFileRepository>();
                For<IAccountService>().Use<AccountService>();
                For<IMediaService>().Use<MediaService>();
                For<IUserService>().Use<UserService>();
            }));
        }
    }
}