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
                MemberId = members.MemberId,
                Name = members.Name,
                LastName = members.LastName,
                SecondLastName = members.SecondLastName,
                CurrentLocationId = members.CurrentLocationId,
                MemberRegistration = DateTime.Today,
                Email = members.Email,
                User = members.User,
                Password = members.Password,
                PhoneNumber = members.PhoneNumber,
                CV = members.CV,
                isAdmin = members.isAdmin,
                isMentor = members.isMentor,
                Feedback = members.Feedback,
                StatusId = members.StatusId
            };

        #endregion

        #region BootCampersMapping
        public static BootCampers Map(this BootCamperDTO bootCamper) =>
            new BootCampers
            {
                BootCamperId = bootCamper.BootCamperId,
                Name = bootCamper.Name,
                LastName = bootCamper.LastName,
                SecondLastName = bootCamper.SecondLastName,
                CurrentLocationId = bootCamper.CurrentLocationId,
                BootCamperRegistration = DateTime.Today,
                Email = bootCamper.Email,
                User = bootCamper.User,
                Password = bootCamper.Password,
                PhoneNumber = bootCamper.PhoneNumber,
                CV = bootCamper.CV,
                isAdmin = bootCamper.isAdmin,
                isMentor = bootCamper.isMentor,
                Feedback = bootCamper.Feedback,
                StatusId = bootCamper.StatusId
            };

        #endregion
    }
}
