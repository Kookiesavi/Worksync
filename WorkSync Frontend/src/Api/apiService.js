const BASE_URL = "https://localhost:44307";

export async function getallEmployees() {
  const response = await fetch(`${BASE_URL}/api/employee`);
  if (!response.ok) {
    throw new Error(`Error fetching employees: ${response.status}`);
  }
  return await response.json();
}
export async function getallTeams() {
  const response = await fetch(`${BASE_URL}/api/team`);
  if (!response.ok) {
    throw new Error(`Error fetching teams: ${response.status}`);
  }
  return await response.json();
}
export async function createEmployee(employeeData) {
  const response = await fetch(`${BASE_URL}/api/employee`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(employeeData),
  });
  if (!response.ok) {
    throw new Error(`Error creating employee: ${response.status}`);
  }
  return await response.json();
}
