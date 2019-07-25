using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace nHibernateDemo
{ 
    class EmployeeMap : ClassMap<Employee>
    {

        public EmployeeMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment(); ;
            Map(x => x.LastName).Length(255).Not.Nullable();
            Map(x => x.FirstName).Length(255).Not.Nullable();
            Map(x => x.Email).Length(255).Not.Nullable();
            References(x => x.Department).Column("DepartmentId").Not.Nullable().Cascade.All();
            Table("employees");
        }
    }
}
