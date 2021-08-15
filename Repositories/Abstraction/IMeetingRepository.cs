﻿using Louman.Models.DTOs;
using Louman.Models.DTOs.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Louman.Repositories.Abstraction
{
    public interface IMeetingRepository
    {
        
        Task<List<SlotDto>> GetAllSlots();
        Task<bool> DeleteSlot(int slotId);

    }
}
