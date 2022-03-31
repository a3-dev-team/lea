import { InjectionToken } from '@angular/core';
import { IEnvironment } from './environment.interface';


/**
 * @const ENVIRONMENT
 * Injection token for the environment interface to be provided by the applications.
 */
export const ENVIRONMENT: InjectionToken<IEnvironment> = new InjectionToken('ENVIRONMENT');