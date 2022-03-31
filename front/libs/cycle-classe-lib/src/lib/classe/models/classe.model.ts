export class Classe {
    id: number = 0;
    nom!: string;

    constructor(init?: Partial<Classe>) {
        Object.assign(this, init);
    }
}
