import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WebcamModule } from 'ngx-webcam';
import { ValidationObjectifComponent } from './validation-objectif.component';


describe('ValidationObjectifComponent', () => {
  let component: ValidationObjectifComponent;
  let fixture: ComponentFixture<ValidationObjectifComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        WebcamModule
      ],
      declarations: [ValidationObjectifComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidationObjectifComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
