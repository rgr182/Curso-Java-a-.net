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
        public static BootcampCandidates Map(this BootcampCandidatesDTO bootcampCandidates) =>
            new BootcampCandidates
            {
                BootcampCandidateId = bootcampCandidates.BootcampCandidateId,
                Name = bootcampCandidates.Name,
                Email = bootcampCandidates.Email,
                PhoneNumber = bootcampCandidates.PhoneNumber,
                StatusId = bootcampCandidates.StatusId,
                Feedback = bootcampCandidates.Feedback,
                BootcampId = bootcampCandidates.BootcampId,


            };

        #endregion

        #region BootcampsMapping

        public static Bootcamps Map(this BootcampsDTO bootcamps) =>
            new Bootcamps
            {
                BootcampId = bootcamps.BootcampId,
                Name = bootcamps.Name,
                StartDate = bootcamps.StartDate,
                EndDate = bootcamps.EndDate,
                Feedback1 = bootcamps.Feedback1,
                Feedback2 = bootcamps.Feedback2,
                Feedback3 = bootcamps.Feedback3,
                StatusId = bootcamps.StatusId,
                CurrentLocationId = bootcamps.CurrentLocationId,
            };
        #endregion

        #region ProjectsMapping

        public static Projects Map(this ProjectsDTO projects) =>
            new Projects
            {
                ProjectId = projects.ProjectId,
                Name = projects.Name,
                StartDate = projects.StartDate,
                EndDate = projects.EndDate,
                StatusId = projects.StatusId,
                CurrentLocationId = projects.CurrentLocationId,
            };
        #endregion
    }
}
