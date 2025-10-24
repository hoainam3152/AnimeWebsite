export interface IResponseData<Entity> {
    status: number;
    message: string;
    data: Entity;
}