using Microsoft.EntityFrameworkCore;
using Production.Contracts;
using Production.Entities.AdventureContexts;
using Production.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Repository
{
    public class UnitMeasureRepository : RepositoryBase<UnitMeasure>, IUnitMeasureRepository
    {
        public UnitMeasureRepository(AdventureContext adventure) : base(adventure)
        {
        }

        public async Task<UnitMeasure> GetUnitMeasureByID(string unitID, bool trackChanges)
        => await FindByCondition(x => x.UnitMeasureCode.Equals(unitID), trackChanges).SingleOrDefaultAsync();
    }
}
