﻿

namespace BlazorAppQLDT.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heroes { get; set; }
        List<Comic> Comics { get; set; }
        Task GetComics();
        Task GetSuperHeroes();
        Task<SuperHero> GetSingleHero(int id);
        /*     Task<SuperHero> UpdateHero(SuperHero hero, int id);*/
     /*   Task<SuperHero> CreateHero(SuperHero hero);*/
        Task CreateHero(SuperHero hero);
        Task UpdateHero(SuperHero hero);
        Task DeleteHero(int id);
    }
}
