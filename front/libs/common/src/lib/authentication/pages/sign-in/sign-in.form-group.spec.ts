import { FormGroup } from '@angular/forms';
import { SignInFormGroup } from './sign-in.form-group';

describe('SingInFormGroup', () => {

    it('form invalid when empty', () => {
        expect(SignInFormGroup.formGroup.valid).toBeFalse();
    });

    describe('login', () => {
        it('initial value => should return invalid', () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;
            const loginFormControl = formGroup.controls['login']

            //Assert
            const errors = loginFormControl.errors || {};
            expect(loginFormControl.valid).toBeFalse;
            expect(errors['required']).toBeTruthy();
        })

        it('not a email => should return invalid', () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;
            const loginFormControl = formGroup.controls['login']
            loginFormControl.setValue('login')

            //Assert
            const errors = loginFormControl.errors || {};
            expect(loginFormControl.valid).toBeFalse;
            expect(errors['email']).toBeTruthy();
        })

        it('a email => should return valid', () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;
            const loginFormControl = formGroup.controls['login']
            loginFormControl.setValue('a3@lea.fr');

            //Assert
            expect(loginFormControl.valid).toBeTrue;
        })
    })

    describe('password', () => {
        it('initial value => should return invalid', () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;
            const passwordControl = formGroup.controls['password']

            //Assert
            const errors = passwordControl.errors || {};
            expect(passwordControl.valid).toBeFalse;
            expect(errors['required']).toBeTruthy();
        })

        it('less than 8 caracters => should return invalid', () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;
            const passwordControl = formGroup.controls['password']
            passwordControl.setValue('login')

            //Assert
            const errors = passwordControl.errors || {};
            expect(passwordControl.valid).toBeFalse;
            expect(errors['minlength']).toBeTruthy();
        })

        it('password >=8 => should return valid', () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;
            const passwordControl = formGroup.controls['password']
            passwordControl.setValue('a3@lea.fr');

            //Assert
            expect(passwordControl.valid).toBeTrue;
        })
    })


})

