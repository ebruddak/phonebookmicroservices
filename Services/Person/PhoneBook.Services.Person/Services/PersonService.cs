using AutoMapper;
using MongoDB.Driver;
using PhoneBook.Services.MsPerson.Dtos;
using PhoneBook.Services.MsPerson.Models;
using PhoneBook.Services.MsPerson.Settings;
using PhoneBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsPerson.Services
{
    public class PersonService:IPersonService
    {
        private readonly IMongoCollection<Person> _personCollection;
        private readonly IMapper _mapper;

        public PersonService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _personCollection = database.GetCollection<Person>(databaseSettings.PersonCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<PersonDto>>> GetAllAsync()
        {
            var persons = await _personCollection.Find(category => true).ToListAsync();

            return Response<List<PersonDto>>.Success(_mapper.Map<List<PersonDto>>(persons), 200);
        }

        public async Task<Response<PersonDto>> CreateAsync(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            await _personCollection.InsertOneAsync(person);

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }

        public async Task<Response<PersonDto>> GetByIdAsync(string id)
        {
            var person = await _personCollection.Find<Person>(x => x.UUID == id).FirstOrDefaultAsync();

            if (person == null)
            {
                return Response<PersonDto>.Fail("Person not found", 404);
            }

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }
    }
}
