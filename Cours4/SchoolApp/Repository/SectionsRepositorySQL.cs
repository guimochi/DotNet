using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApp.Models;

namespace SchoolApp.Repository
{
    class SectionsRepositorySQL : BaseRepositorySQL<Section>
    {
        public SectionsRepositorySQL(SchoolContext context) : base(context) { }
    }
}
