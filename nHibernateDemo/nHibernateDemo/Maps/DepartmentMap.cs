using FluentNHibernate.Mapping;

namespace nHibernateDemo
{
    class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment(); ;
            Map(x => x.Name).Length(255).Not.Nullable();
            Map(x => x.NumOfEmployee).Not.Nullable();
            HasMany(x => x.Employees).Cascade.AllDeleteOrphan().Inverse();
            Table("departments");
        }
    }
}
