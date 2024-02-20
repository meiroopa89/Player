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

  // fit('Frontend_should_call_the_API_and_register_the_user_when_register_is_called', () => {
  //   const registerData = { username: 'test', password: 'password', userrole: 'admin', email: 'test@test.com', mobileNumber: '1234567890' };
  //   const response = { id: '1', ...registerData };
  
  //   (service as any).register(registerData.username, registerData.password, registerData.userrole, registerData.email, registerData.mobileNumber).subscribe();
  
  //   const req = httpMock.expectOne(`${(service as any).apiUrl}/api/register`); // Expect a POST request to the register API
  //   expect(req.request.method).toBe('POST');
  //   expect(req.request.body).toEqual(registerData);
  
  //   req.flush(response); // Return the response object when the request is made
  // });


  fit('should register a new user', () => {
    const registerData = {
      username: 'testuser',
      password: 'testpassword',
      userRole: 'ustomer',
      email: 'test@test.com',
      mobileNumber: '1234567890'
    };

    service.register(
      registerData.username,
      registerData.password,
      registerData.userRole,
      registerData.email,
      registerData.mobileNumber
    ).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/register`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(registerData);

    req.flush({}); // You can modify the response as needed
  });


  fit('Frontend_should_call_the_API_and_authenticate_the_user_when_login_is_called', () => {
    const loginData = { email: 'test@test.com', password: 'password' };
  const response = { username: 'test', userrole: 'admin', id: '1' };

  (service as any).login(loginData.email, loginData.password).subscribe();

  const req = httpMock.expectOne(`${(service as any).apiUrl}/api/login`); // Expect a POST request to the login API
  expect(req.request.method).toBe('POST');
  expect(req.request.body).toEqual(loginData);

  req.flush(response); // Return the response object when the request is made
  });

  fit('should logout a user and remove user data from localStorage', () => {
    // Set initial user data in localStorage
    localStorage.setItem('token', 'testToken');
    localStorage.setItem('userRole', 'customer');
    localStorage.setItem('userId', '1');

    service.logout();

    // Check if user data is removed from localStorage
    expect(localStorage.getItem('token')).toBeNull();
    expect(localStorage.getItem('userRole')).toBeNull();
    expect(localStorage.getItem('userId')).toBeNull();
  });
  
});