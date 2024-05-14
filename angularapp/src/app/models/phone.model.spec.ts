import { Phone } from './phone.model'; // Import Phone model

describe('Phone', () => { // Updated description to 'Phone'
  fit('should_create_phone_instance', () => { // Updated 'fit' to 'it' and updated test description
    const phone: Phone = { // Updated 'recipe' to 'phone' and 'Recipe' to 'Phone'
      phoneId: 1, // Adjusted property name
      brand: 'Test Brand', // Adjusted property name
      model: 'Test Model', // Adjusted property name
      screenSize: 6, // Adjusted property name
      storageCapacity: 128, // Adjusted property name
      ram: 8, // Adjusted property name
      batteryCapacity: 4000 // Adjusted property name
    };

    // Check if the phone object exists
    expect(phone).toBeTruthy();

    // Check individual properties of the phone
    expect(phone.phoneId).toBe(1); // Adjusted property name
    expect(phone.brand).toBe('Test Brand'); // Adjusted property name
    expect(phone.model).toBe('Test Model'); // Adjusted property name
    expect(phone.screenSize).toBe(6); // Adjusted property name
    expect(phone.storageCapacity).toBe(128); // Adjusted property name
    expect(phone.ram).toBe(8); // Adjusted property name
    expect(phone.batteryCapacity).toBe(4000); // Adjusted property name
  });
});
