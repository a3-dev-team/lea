import { IEnvironment } from '../environment/environment.interface';
import { IApiProperties } from './api-properties.interface';

export class UrlHelper {
    public static GetBackApiUrl(environment: IEnvironment, apiProperties: IApiProperties) {
        return `${UrlHelper.GetBackBaseUrl(environment)}api/lea/${apiProperties.domainName}/v${apiProperties.apiVersion}/`
    }

    public static GetBackBaseUrl(environment: IEnvironment) {
        if (environment.production) {
            return window.location.origin;
        } else {
            return environment.backUrl;
        }
    }
}
