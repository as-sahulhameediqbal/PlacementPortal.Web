﻿using PlacementPortal.Shared.Common;

namespace PlacementPortal.Domain.Entities
{
    public class UserType : EntityBase
    {
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
