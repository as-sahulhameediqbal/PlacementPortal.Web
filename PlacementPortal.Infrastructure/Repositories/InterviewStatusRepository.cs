﻿using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Infrastructure.Common;

namespace PlacementPortal.Infrastructure.Repositories
{
    public class InterviewStatusRepository : GenericRepository<InterviewStatus>, IInterviewStatusRepository
    {
        public InterviewStatusRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
