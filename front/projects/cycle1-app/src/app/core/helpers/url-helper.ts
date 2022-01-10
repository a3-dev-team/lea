import { environment } from 'projects/cycle1-app/src/environments/environment';

export class UrlHelper {
    public static get backApiUrl() {
        return UrlHelper.backBaseUrl + '/api/lea/cycle1/v1';
    }

    public static get backBaseUrl() {
        if (environment.production) {
            return window.location.origin;
        } else {
            return environment.backUrl;
        }
    }
}
