
export class Professeur {
    public id: number = 0;
    public nom!: string;
    public prenom!: string;
    public dateNaissance!: Date;
    public email!: string;
    public classeId!: number;

    constructor(init?: Partial<Professeur>) {
        Object.assign(this, init);
    }
}
