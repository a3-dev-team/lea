import { Objectif } from '../../objectif/models/objectif.model';

export class ObjectifEleve {
    public eleveId: number = 0;
    public objectifId: number = 0;
    public dateValidation!: Date | null;
    public photos!: string;
    public objectif!: Objectif;

    constructor(init?: Partial<ObjectifEleve>) {
        Object.assign(this, init);
    }
}