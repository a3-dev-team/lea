import { FormControl, FormGroup, Validators } from '@angular/forms';

export class SignInFormGroup {
    public static get formGroup(): FormGroup {
        return new FormGroup({
            login: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required, Validators.minLength(8)]),
        });
    }
} 