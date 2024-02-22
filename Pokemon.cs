using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIDEX
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("types")]
        public PokemonType[] Types { get; set; }

        [JsonProperty("abilities")]
        public PokemonAbility[] Abilities { get; set; }

        public class PokemonType
        {
            [JsonProperty("slot")]
            public int Slot { get; set; }

            [JsonProperty("type")]
            public TypeDetails Type { get; set; }
        }

        public class TypeDetails
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class PokemonAbility
        {
            [JsonProperty("is_hidden")]
            public bool IsHidden { get; set; }

            [JsonProperty("ability")]
            public AbilityDetails Ability { get; set; }
        }

        public class AbilityDetails
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }

    }
}
