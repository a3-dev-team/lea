export class Objectif {
  public id: number = 0;
  public libelle!: string;
  public pictogramme!: string;
  public description!: string;

  constructor(init?: Partial<Objectif>) {
    Object.assign(this, init);
  }
}
