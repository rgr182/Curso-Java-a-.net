using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.DTO.DTOMapping
{
    public static class DTOMappings
    {
        #region TechMapping
        public static Technologies Map(this TechnologyDTO tech)
            => new Technologies
            {
                TechnologyId = tech.TechnologyId,
                Name = tech.Name
            };
        #endregion

        #region MembersMapping

        public static Member Map(this MemberDTO members) =>
            new Member
            {
                MemberId = members.MemberId,
                Name = members.Name,
                LastName = members.LastName,
                SecondName = members.SecondName,
                CurrentLocationId = members.CurrentLocationId,
                MemberRegistration = members.MemberRegistration,
                Email = members.Email,
                User = members.User,
                Password = members.Password,
                PhoneNumber = members.PhoneNumber,
                CV = members.CV

            };

        #endregion
    }
}
