export const API_PATH = "https://localhost:44322/api/";

export const API_ROUTES = {
    register: API_PATH + "auth/register/",
    changePassword: API_PATH + "auth/changePassword/",
    login: API_PATH + "auth/login/",
    products: API_PATH + "products/",
    account: API_PATH + "account/",
    diary: API_PATH + "diary/",
    receipts: API_PATH + "receipts/"
}

export const ACCESS_TOKEN: string = "access_token";
export const REFRESH_TOKEN: string = "refresh_token";

export const APP_ROUTES = {
  admin: "admin-panel",
  auth: "auth",
  main: "main"
}