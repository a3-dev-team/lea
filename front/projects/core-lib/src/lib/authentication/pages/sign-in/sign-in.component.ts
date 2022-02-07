import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UserSignIn } from '../../models/user-sign-in.model';
import { AuthenticationManager } from '../../services/authentication-manager.service';

@Component({
  selector: 'lib-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  public authenticationFormGroup = new FormGroup({
    login: new FormControl('', Validators.required),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
  });

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
