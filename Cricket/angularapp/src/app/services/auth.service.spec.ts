import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { AuthService } from './auth.service';

describe('AuthService', () => {
  let service: AuthService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AuthService]
    });

    service = TestBed.inject(AuthService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify(); // Ensure that there are no outstanding requests
  });


  fit('Frontend_should_call_the_API_and_register_the_user_when_register_is_called', () => {
    const registerData = {
      Username: 'testuser',
      Password: 'testpassword',
      UserRole: 'Organizer',
      Email: 'test@test.com',
      MobileNumber: '1234567890'
    };
    const response = { id: 1, ...registerData };  

    service.register(
      registerData.Username,
      registerData.Password,
      registerData.UserRole,
      registerData.Email,
      registerData.MobileNumber
    ).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/register`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(registerData);

    req.flush(response);
  });


  fit('Frontend_should_call_the_API_and_authenticate_the_admin_when_login_is_called', () => {
    const loginData = { Email: 'test@test.com', Password: 'password' };
  const response = { Username: 'test', userRole: 'Admin', UserId: 1 };

  (service as any).login(loginData.Email, loginData.Password).subscribe();

  const req = httpMock.expectOne(`${(service as any).apiUrl}/api/login`); // Expect a POST request to the login API
  expect(req.request.method).toBe('POST');
  expect(req.request.body).toEqual(loginData);

  req.flush(response); // Return the response object when the request is made
  });

  fit('Frontend_should_call_the_API_and_authenticate_the_organizer_when_login_is_called', () => {
    const loginData = { Email: 'test@test.com', Password: 'password' };
  const response = { username: 'test', userRole: 'Organizer', UserId: 1 };

  (service as any).login(loginData.Email, loginData.Password).subscribe();

  const req = httpMock.expectOne(`${(service as any).apiUrl}/api/login`); // Expect a POST request to the login API
  expect(req.request.method).toBe('POST');
  expect(req.request.body).toEqual(loginData);

  req.flush(response); // Return the response object when the request is made
  });
  
});