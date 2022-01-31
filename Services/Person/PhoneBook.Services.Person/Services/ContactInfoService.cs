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
    public class ContactInfoService : IContactInfoService
    {
        private readonly IMongoCollection<ContactInfo> _contactInfoCollection;
        private readonly IMongoCollection<Person> _personCollection;
        private readonly IMapper _mapper;

        public ContactInfoService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _contactInfoCollection = database.GetCollection<ContactInfo>(databaseSettings.ContactInfoCollectionName);

            _personCollection = database.GetCollection<Person>(databaseSettings.PersonCollectionName);
            _mapper = mapper;

        }

        public async Task<Response<List<ContactInfoDto>>> GetAllAsync()
        {
            var ContactInfos = await _contactInfoCollection.Find(ContactInfo => true).ToListAsync();

            if (ContactInfos.Any())
            {
                foreach (var ContactInfo in ContactInfos)
                {
                    ContactInfo.Person = await _personCollection.Find<Person>(x => x.UUID == ContactInfo.PersonID).FirstAsync();
                }
            }
            else
            {
                ContactInfos = new List<ContactInfo>();
            }

            return Response<List<ContactInfoDto>>.Success(_mapper.Map<List<ContactInfoDto>>(ContactInfos), 200);
        }

        public async Task<Response<ContactInfoDto>> GetByIdAsync(string id)
        {
            var ContactInfo = await _contactInfoCollection.Find<ContactInfo>(x => x.ID == id).FirstOrDefaultAsync();

            if (ContactInfo == null)
            {
                return Response<ContactInfoDto>.Fail("ContactInfo not found", 404);
            }
            ContactInfo.Person = await _personCollection.Find<Person>(x => x.UUID == ContactInfo.PersonID).FirstAsync();

            return Response<ContactInfoDto>.Success(_mapper.Map<ContactInfoDto>(ContactInfo), 200);
        }

        public async Task<Response<List<ContactInfoDto>>> GetAllByUserIdAsync(string userId)
        {
            var ContactInfos = await _contactInfoCollection.Find<ContactInfo>(x => x.PersonID == userId).ToListAsync();

            if (ContactInfos.Any())
            {
                foreach (var ContactInfo in ContactInfos)
                {
                    ContactInfo.Person = await _personCollection.Find<Person>(x => x.UUID == ContactInfo.PersonID).FirstAsync();
                }
            }
            else
            {
                ContactInfos = new List<ContactInfo>();
            }

            return Response<List<ContactInfoDto>>.Success(_mapper.Map<List<ContactInfoDto>>(ContactInfos), 200);
        }

        public async Task<Response<ContactInfoDto>> CreateAsync(ContactInfoCreateDto ContactInfoCreateDto)
        {
            var newContactInfo = _mapper.Map<ContactInfo>(ContactInfoCreateDto);

            await _contactInfoCollection.InsertOneAsync(newContactInfo);

            return Response<ContactInfoDto>.Success(_mapper.Map<ContactInfoDto>(newContactInfo), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(ContactInfoUpdateDto ContactInfoUpdateDto)
        {
            var updateContactInfo = _mapper.Map<ContactInfo>(ContactInfoUpdateDto);

            var result = await _contactInfoCollection.FindOneAndReplaceAsync(x => x.ID == ContactInfoUpdateDto.ID, updateContactInfo);

            if (result == null)
            {
                return Response<NoContent>.Fail("ContactInfo not found", 404);
            }

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _contactInfoCollection.DeleteOneAsync(x => x.ID == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("ContactInfo not found", 404);
            }
        }
    }
}