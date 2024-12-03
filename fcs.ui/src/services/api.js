import axios from "axios";

const API_BASE_URL = "https://fictional-civ-sim-api.onrender.com/api"; // Local development

const axiosInstance = axios.create({
  baseURL: API_BASE_URL,
  timeout: 5000, // Timeout after 5 seconds
});

// Interceptor to handle errors
axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    // Extract error message
    const message =
      error.response?.data?.message ||
      error.response?.statusText ||
      "An unexpected error occurred";
    return Promise.reject(new Error(message));
  }
);

export const getCivilizations = async () => {
  try {
    const response = await axiosInstance.get("/civilization");
    return response.data;
  } catch (error) {
    throw error; // Propagate error to be handled in the component
  }
};

export const getCivilization = async (id) => {
  try {
    const response = await axiosInstance.get(
      `${API_BASE_URL}/civilization/${id}`
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const createCivilization = async (data) => {
  try {
    const response = await axiosInstance.post(
      `${API_BASE_URL}/civilization`,
      data
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const evolveCivilization = async (id, turns) => {
  try {
    const response = await axiosInstance.put(
      `${API_BASE_URL}/civilization/${id}/evolve?turns=${turns}`
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};
