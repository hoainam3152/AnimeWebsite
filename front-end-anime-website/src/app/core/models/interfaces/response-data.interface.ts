export interface IResponseData<TEntity> {
    statusCode: number;
    message: string;
    data: TEntity;
}