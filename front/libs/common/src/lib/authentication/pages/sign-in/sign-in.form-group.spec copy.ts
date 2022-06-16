import { FormGroup } from '@angular/forms';
import { SignInFormGroup } from './sing-in.form-group';

describe('SingInFormGroup', () => {
    describe('login', () => {
        it('initial value => should return invalid'), () => {
            //Arrange
            //Assign
            expect(1).toBe(2);
            // const formGroup: FormGroup = SignInFormGroup.formGroup;
            // const loginFormControl = formGroup.controls['login']

            // //Assert
            // expect(loginFormControl.valid).toBeFalsy;
        }

        it('not a email => should return invalid'), () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;
            const loginFormControl = formGroup.controls['login']
            loginFormControl.setValue('login')

            //Assert
            expect(loginFormControl.valid).toBe(false);
        }

        it('email => should return valid'), () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;
            const loginFormControl = formGroup.controls['login']
            loginFormControl.setValue('login');

            //Assert
            expect(loginFormControl.valid).toBe(true);
        }
    })

    describe('password', () => {
        it('initial value => should return invalid'), () => {
            //Arrange
            //Assign
            const formGroup: FormGroup = SignInFormGroup.formGroup;

            //Assert
            expect(formGroup.controls['login'].valid).toBe(false);
        }
    })


})