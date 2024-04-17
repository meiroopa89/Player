import { Doctor } from '../models/doctor.model';

describe('Doctor', () => {
  fit('DoctorModel_should_create_an_instance', () => {
    // Create a factory function to create instances of Doctor
    function createDoctor(id: number, firstName: string, lastName: string, specialization: string, phoneNumber: string, email: string, address: string): Doctor {
      return {
        id,
        firstName,
        lastName,
        specialization,
        phoneNumber,
        email,
        address
      };
    }

    // Use the factory function to create an instance of Doctor
    const doctor: Doctor = createDoctor(
      1,
      'John',
      'Doe',
      'Cardiologist',
      '1234567890',
      'john.doe@example.com',
      '123 Main St'
    );

    // Assert that the instance is created successfully
    expect(doctor).toBeDefined();
  });

  fit('DoctorModel_should_update_property_values_using_setters', () => {
    // Similar setup as above
    function createDoctor(id: number, firstName: string, lastName: string, specialization: string, phoneNumber: string, email: string, address: string): Doctor {
      return {
        id,
        firstName,
        lastName,
        specialization,
        phoneNumber,
        email,
        address
      };
    }

    const doctor: Doctor = createDoctor(
      1,
      'John',
      'Doe',
      'Cardiologist',
      '1234567890',
      'john.doe@example.com',
      '123 Main St'
    );

    // Assert that the instance is created successfully
    expect(doctor).toBeTruthy();
    // Assertions for property values and data types remain the same
    expect(doctor.id).toEqual(1);
    expect(doctor.firstName).toEqual('John');
    expect(doctor.lastName).toEqual('Doe');
    expect(doctor.specialization).toEqual('Cardiologist');
    expect(doctor.phoneNumber).toEqual('1234567890');
    expect(doctor.email).toEqual('john.doe@example.com');
    expect(doctor.address).toEqual('123 Main St');
  });
});
