using server.Dto.Application;
using server.Models;

namespace server.Mappers
{
    public static class ApplicationMapper
    {
        public static Application ToApplicationFromUpdateAppDto (this UpdateApplicationDto updateApplicationDto)
        {
            return new Application 
            {
                FirstName = updateApplicationDto.FirstName,
                MiddleName = updateApplicationDto.MiddleName,
                LastName = updateApplicationDto.LastName,
                Email = updateApplicationDto.Email,
                Mobile = updateApplicationDto.Mobile,
                Gender = updateApplicationDto.Gender,
                Address = updateApplicationDto.Address,
                Resume = updateApplicationDto.Resume,
                DoB = DateOnly.Parse(updateApplicationDto.DoB)
            };
        } 
    }
}
