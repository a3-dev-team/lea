import { IEnvironment } from '../environment/environment.interface';
import { IApiProperties } from './api-properties.interface';

export class UrlHelper {

    public static GetBackApiUrl(environment: IEnvironment, apiProperties: IApiProperties) {
        return `${UrlHelper.GetBackBaseUrl(environment)}api/lea/${apiProperties.domainName}/v${apiProperties.apiVersion}/`
    }

    public static GetBackBaseUrl(environment: IEnvironment) {
        let backBaseUrl: string;

        if (environment.production) {
            backBaseUrl = window.location.origin;
        } else {
            backBaseUrl = environment.backUrl;
        }

        if (!backBaseUrl.endsWith('/')) {
            backBaseUrl += '/';
        }

        return backBaseUrl;
    }

}
