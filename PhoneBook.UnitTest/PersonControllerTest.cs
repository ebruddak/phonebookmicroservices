using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneBook.Services.MsPerson.Controllers;
using PhoneBook.Services.MsPerson.Models;
using PhoneBook.Services.MsPerson.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneBook.UnitTest
{
    public class PersonControllerTest
    {
        private readonly Mock<IPersonService> _mockRepo;
        private readonly PersonsController _controller;
        private List<Person> persons;

        public PersonControllerTest()
        {
            _mockRepo = new Mock<IPersonService>();
            _controller = new PersonsController(_mockRepo.Object);
            persons = new List<Person>()
            {
                new Person{
                          UUID= "61f5c155fd58771086867b50",
                          Name="Ebruli",
                          Surname= "Ebru",
                          Company= "Unibim Bilisim"
                          },new Person{
                          UUID= "61f5c155fd58771086867b50",
                          Name="Ebruli",
                          Surname= "Ebru",
                          Company= "Unibim Bilisim"
                          },new Person{
                          UUID= "61f5c155fd58771086867b50",
                          Name="Ebruli",
                          Surname= "Ebru",
                          Company= "Unibim Bilisim"
                          },new Person{
                          UUID= "61f5c155fd58771086867b50",
                          Name="Ebruli",
                          Surname= "Ebru",
                          Company= "Unibim Bilisim"
                          }
            };
        }
        [Fact]
        public async void GetAll_ActionExecutes_ReturnPersons()
        {
            _mockRepo.Setup(x => x.GetAllAsync());

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnPerson = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
            Assert.Equal<int>(4, returnPerson.ToList().Count);
        }
    }
}
