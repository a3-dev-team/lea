import { environment } from 'projects/cycle1-app/src/environments/environment';

export class UrlHelper {
    public static get cycle1BackApiUrl() {
        return UrlHelper.backBaseUrl + '/api/lea/cycle1/v1/';
    }
    public static get sharedBackApiUrl() {
        return UrlHelper.backBaseUrl + '/api/lea/shared/v1/';
    }


    public static get backBaseUrl() {
        if (environment.production) {
            return window.location.origin;
        } else {
            return environment.backUrl;
        }
    }
}
