using System;

namespace pokedexAPI.Entities
{
    public record Pokemon
    {
        public Guid Id{get;init;}

        public string Name{get;init;}

        public string Height{get;init;}

        public DateTimeOffset CreatedDate{get;init;}
    }
}

///with init you can do the following
///ITEM item = new ()
///{ Id  = Guid.NewGuid();}


//BUT YOU CANT DO THIS
//item.Id = Guid.NewGuid();