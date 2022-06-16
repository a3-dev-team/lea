import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserSignIn } from '../../models/user-sign-in.model';
import { AuthenticationManager } from '../../services/authentication-manager.service';
import { SignInFormGroup } from './sign-in.form-group';

@Component({
  selector: 'a3-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  public authenticationFormGroup = SignInFormGroup.formGroup;

  constructor(
    private readonly activatedRoute: ActivatedRoute,
    private readonly authenticationManager: AuthenticationManager
  ) { }

  ngOnInit(): void {
  }

  public onSubmit() {
    const userSignIn: UserSignIn = this.authenticationFormGroup.value;

    this.activatedRoute.queryParamMap
      .subscribe((queryParamMap) => {
        let routeToNavigate: string = '';
        const urlRedirection: string | null = queryParamMap.get('urlRedirection');
        if (urlRedirection) {
          routeToNavigate = urlRedirection;
        }
        this.authenticationManager.signIn(userSignIn, routeToNavigate)
      });
  }

}
