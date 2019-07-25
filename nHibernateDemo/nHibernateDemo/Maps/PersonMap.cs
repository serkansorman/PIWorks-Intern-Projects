using FluentNHibernate.Mapping;


namespace nHibernateDemo
{   
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).Column("id").Not.Nullable().GeneratedBy.Increment(); ;
            Map(x => x.LastName).Column("lastname").Length(255).Not.Nullable();
            Map(x => x.FirstName).Column("firstname").Length(255).Not.Nullable();
            Map(x => x.Email).Column("email").Length(255).Not.Nullable();
            Table("people");
        }

    }

}
