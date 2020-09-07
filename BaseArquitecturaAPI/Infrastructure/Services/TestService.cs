using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    /// <summary>
    /// This class implement TestService Interface and is responsable of connecting to db or to http requests
    /// </summary>
    public class TestService : ITestService
    {

        public TestService()
        {

        }
        public Task<List<TestEntity>> GetAllTests()
        {
            throw new NotImplementedException();
        }

        //by the moment
        public Task<TestEntity> GetTestById(int id)
        {
            return null;
                /*new TestEntity
            {
                IdTest = 1,
                Description = "Esta es la base",
                Name = "Test",
                State = true
            };*/
        }
    }
}
