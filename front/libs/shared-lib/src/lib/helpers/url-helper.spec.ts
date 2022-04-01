import { IEnvironment } from '../environment/environment.interface'
import { IApiProperties } from './api-properties.interface'
import { UrlHelper } from './url-helper'

describe('UrlHelper', () => {

    describe('GetBackBaseUrl', () => {

        it(`devrait retourner 'windows.location'`, () => {
            const environment: IEnvironment = {
                production: true,
                backUrl: 'https://localhost:7057/',
                tokenName: 'tokenName'
            }

            const backBaseUrl: string = UrlHelper.GetBackBaseUrl(environment);

            expect(backBaseUrl).not.toBe("https://localhost:7057")
        })

        it(`devrait retourner 'environment.backUrl'`, () => {
            const environment: IEnvironment = {
                production: false,
                backUrl: 'https://localhost:7057/',
                tokenName: 'tokenName'
            }

            const backBaseUrl: string = UrlHelper.GetBackBaseUrl(environment);

            expect(backBaseUrl).toBe("https://localhost:7057/")
        })

        it(`devrait retourner 'environment.backUrl' avec un '/'`, () => {
            const environment: IEnvironment = {
                production: false,
                backUrl: 'https://localhost:7057',
                tokenName: 'tokenName'
            }

            const backBaseUrl: string = UrlHelper.GetBackBaseUrl(environment);

            expect(backBaseUrl).toBe("https://localhost:7057/")
        })

    })

    describe('GetBackApiUrl', () => {

        it(`devrait retourner 'https://localhost:7057/api/lea/testDomain/v2/'`, () => {
            const environment: IEnvironment = {
                production: false,
                backUrl: 'https://localhost:7057/',
                tokenName: 'tokenName'
            }

            const apiProperties: IApiProperties = {
                domainName: 'testDomain',
                apiVersion: 2
            }

            const backApiUrl: string = UrlHelper.GetBackApiUrl(environment, apiProperties);

            expect(backApiUrl).toBe("https://localhost:7057/api/lea/testDomain/v2/")
        })

    })
})