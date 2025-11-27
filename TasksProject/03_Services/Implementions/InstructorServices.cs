using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using TasksProject._02_Repositories.Interfaces;
using TasksProject._03_Services.Interfaces;
using TasksProject.Models;

namespace TasksProject._03_Services.Implementions
{
    public class InstructorServices : IInstructorServices
    {
        private readonly IGenericRepo<Instructor> genericRepo;
        private readonly IInstructorRepo _instructorRepo;


        public InstructorServices(IGenericRepo<Instructor> genericRepo, IInstructorRepo instructorRepo)
        {
            this.genericRepo = genericRepo;
            _instructorRepo = instructorRepo;
        }

        public async Task AddInstructor(Instructor model)
        {
            await genericRepo.AddAsync(model);
        }

        public Task<List<Instructor>> GetAllInstructor()
        {
           var allinstructor = genericRepo.GetAllAsync();
            return allinstructor;
        }

       

        public async Task<List<Instructor>> GetAllInstructor_RelatedData()
        {
            var instructors= await _instructorRepo.GetAllInstructor_RelatedData();
            return instructors;
        }

        public async Task<List<Course>?> GetCourseofInstructor(int instructorid)
        {
          var corse= await _instructorRepo.GetCourseofInstructor(instructorid);
            return corse;
        }

        public Task<Instructor> GetInstructorDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Instructor> GetInstructoreById(int id)
        {
            var instructor = genericRepo.GetByidAsync(id);
            if (instructor is null)
            {
                throw new ArgumentNullException(nameof(instructor));
            }    
            return instructor;
        }

        public async Task RemoveInstructor(Instructor model)
        {
            await genericRepo.DeleteAsync(model);
        }

        public async Task UpdateInstructor(Instructor model)
        {
            await genericRepo.UpdateAsync(model);
        }
    }
}
