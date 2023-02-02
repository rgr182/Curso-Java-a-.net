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

        #region BootcampCandidatesMapping
        public static BootcampCandidates Map(this BootcampCandidatesDTO BootcampCandidates) =>
            new BootcampCandidates
            {
                BootcampCandidateId = BootcampCandidates.BootcampCandidateId,
                Name = BootcampCandidates.Name,
                Email = BootcampCandidates.Email,
                PhoneNumber = BootcampCandidates.PhoneNumber,
                StatusId = BootcampCandidates.StatusId,
                Feedback = BootcampCandidates.Feedback,
                BootcampId = BootcampCandidates.BootcampId,


            };

        #endregion
    }
}
