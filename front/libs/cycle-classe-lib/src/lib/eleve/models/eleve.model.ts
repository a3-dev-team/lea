
export class Eleve {
    public id: number = 0;
    public nom!: string;
    public prenom!: string;
    public dateNaissance!: Date;
    public emails!: string[];

    constructor(init?: Partial<Eleve>) {
        Object.assign(this, init);
    }
}
