import { Injectable } from '@angular/core';
import { SuperHero } from '../models/super-hero';

@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {

  constructor() { }

  public getSuperHeroes() : SuperHero[]{
    let hero = new SuperHero();
    hero.id = 0;
    hero.name = "Batman";
    hero.firstName = "Bruce";
    hero.lastName = "Wayne";
    hero.place = "Gotham City";
    return [hero];
  }
}
