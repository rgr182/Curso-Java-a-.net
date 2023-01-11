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

        public static Members Map(this MemberDTO members) =>
            new Members
            {
                MembersId = members.MembersId,
                Name = members.Name,
                FirstName = members.FirstName,
                SecondName = members.SecondName,
                CurrentLocationId = members.CurrentLocationId,
                MemberRegistratior = members.MemberRegistratior,
                Email = members.Email,
                User = members.User,
                Password = members.Password,
                PhoneNumber = members.PhoneNumber,
                CV = members.CV
            };

        #endregion
    }
}
