﻿using Database.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database
{
    public interface IRepairRepository
    {
        Task<List<RepairDomainModel>> GetAllAsync();
        Task<RepairDomainModel> GetByIdAsync(RepairDomainModel model);
        Task<RepairDomainModel> UpdateAsync(RepairDomainModel model);
        Task DeleteAsync(RepairDomainModel model);
        Task<RepairDomainModel> CreateAsync(RepairDomainModel model);
        Task<List<RepairDomainModel>> GetAllByMasterIdAsync(RepairDomainModel model);
        Task<List<RepairDomainModel>> GetAllByClientIdAsync(RepairDomainModel model);
        Task<List<ProductDomainModel>> GetProductsByClientIdAsync(RepairDomainModel model);
    }
}
